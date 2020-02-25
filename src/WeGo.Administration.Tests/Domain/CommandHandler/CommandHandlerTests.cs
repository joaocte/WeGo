using FluentValidation.Results;
using NSubstitute;
using System;
using WeGo.Administration.Core.Domain.Bus;
using WeGo.Administration.Core.Domain.Notifications;
using WeGo.Administration.Domain.Interfaces.UoW;
using WeGo.Administration.Tests.Fakes;
using Xunit;

namespace WeGo.Administration.Tests.Domain.CommandHandler
{
    public class CommandHandlerTests
    {
        private readonly IMediatorHandler bus;
        private readonly WeGo.Administration.Domain.CommandHandlers.CommandHandler commandHandler;
        private readonly IUnitOfWork uow;
        private DomainNotificationHandler notifications;

        public CommandHandlerTests()
        {
            bus = Substitute.For<IMediatorHandler>();
            notifications = Substitute.For<DomainNotificationHandler>();
            uow = Substitute.For<IUnitOfWork>();
            commandHandler = new Administration.Domain.CommandHandlers.CommandHandler(uow, bus, notifications);
        }

        [Fact]
        public void QuandoTentarRealizarCommitENaoTiverNotificacoes_ReturnFalse()
        {
            notifications.HasNotifications().Returns(true);
            Assert.False(commandHandler.Commit().Result);
        }

        [Fact]
        public void QuandoTentarRealizarCommitEUowCommitFalse_ReturnFalse()
        {
            notifications.HasNotifications().Returns(false);
            uow.Commit().Returns(false);
            Assert.False(commandHandler.Commit().Result);
            bus.Received().RaiseEvent(Arg.Any<DomainNotification>());
        }

        [Fact]
        public void QuandoTentarRealizarCommitEUowCommitTrue_ReturnTrue()
        {
            notifications.HasNotifications().Returns(false);
            uow.Commit().Returns(true);
            var result = commandHandler.Commit().Result;
            Assert.True(result);
        }

        [Fact]
        public void QuantoSolicitarNotificacoes_NotifyValidationErrorsCalled()
        {
            var commandHandlerFake = new CommandHandlerFake(uow, bus, notifications);
            var command = new CommandInvalidFake();

            command.ValidationResult = new ValidationResult();
            command.ValidationResult.Errors.Add(new ValidationFailure("propertyName", "errorMessage"));

            commandHandlerFake.NotifyValidationErrors(command);
            bus.Received().RaiseEvent(Arg.Any<DomainNotification>());
            Assert.IsType<DateTime>(command.Timestamp);
        }
    }

    public class CommandInvalidFake : Administration.Core.Domain.Commands.Command
    {
        public override bool IsValid()
        {
            return false;
        }
    }

    public class CommandValidFake : Administration.Core.Domain.Commands.Command
    {
        public override bool IsValid()
        {
            return true;
        }
    }
}