using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using MongoDB.Driver.Core.Operations;
using MongoDB.Driver.Core.WireProtocol.Messages.Encoders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeGo.Administration.Tests.Fakes
{
    public class AsyncCursorFake<T> : AsyncCursor<T>, IAsyncCursor<T> where T : class
    {
        public AsyncCursorFake(IChannelSource channelSource, CollectionNamespace collectionNamespace, BsonDocument query, IReadOnlyList<T> firstBatch, long cursorId, int? batchSize, int? limit, IBsonSerializer<T> serializer, MessageEncoderSettings messageEncoderSettings, TimeSpan? maxTime = null) : base(channelSource, collectionNamespace, query, firstBatch, cursorId, batchSize, limit, serializer, messageEncoderSettings, maxTime)
        {
        }
    }
}