﻿using System;
using Geo.Abstractions.Interfaces;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Geo.Raven.Indexes
{
    public abstract class GeoMultiMapIndexCreationTask : GeoMultiMapIndexCreationTask<object>
    {
    }

    public class GeoMultiMapIndexCreationTask<TReduceResult> : AbstractMultiMapIndexCreationTask<TReduceResult>
    {
        public object GeoIndex(IRavenIndexable shape)
        {
            throw new NotSupportedException("This method is provided solely to allow query translation on the server");
        }

        public object GeoIndex(IRavenIndexable shape, SpatialSearchStrategy strategy)
        {
            throw new NotSupportedException("This method is provided solely to allow query translation on the server");
        }

        public object GeoIndex(IRavenIndexable shape, SpatialSearchStrategy strategy, int maxTreeLevel)
        {
            throw new NotSupportedException("This method is provided solely to allow query translation on the server");
        }

        public override IndexDefinition CreateIndexDefinition()
        {
            return GeoIndexTranformer.Transform(base.CreateIndexDefinition(), Conventions);
        }
    }
}
