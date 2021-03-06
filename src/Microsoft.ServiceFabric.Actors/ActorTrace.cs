﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------
namespace Microsoft.ServiceFabric.Actors
{
    using System;
    using System.Fabric.Common.Tracing;
    using Microsoft.ServiceFabric.Services;

    internal static class ActorTrace
    {
        internal static FabricEvents.ExtensionsEvents Source;

        static ActorTrace()
        {
            TraceConfig.InitializeFromConfigStore();
            Source = new FabricEvents.ExtensionsEvents(FabricEvents.Tasks.ActorFramework);
        }

        internal static string GetTraceIdForActor(Guid partitionId, long replicaId, ActorId actorId)
        {
            return String.Concat(
                GetTraceIdForReplica(partitionId, replicaId),
                ":",
                actorId.GetStorageKey());
        }

        internal static string GetTraceIdForReplica(Guid partitionId, long replicaId)
        {
            return ServiceTrace.GetTraceIdForReplica(partitionId, replicaId);
        }
    }
}
