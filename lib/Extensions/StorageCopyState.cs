﻿//------------------------------------------------------------------------------
// <copyright file="StorageCopyState.cs" company="Microsoft">
//    Copyright (c) Microsoft Corporation
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.DataMovement.Extensions
{
    using System;

    internal enum StorageCopyStatus
    {
        //
        // Summary:
        //     The copy status is invalid.
        Invalid = 0,
        //
        // Summary:
        //     The copy operation is pending.
        Pending = 1,
        //
        // Summary:
        //     The copy operation succeeded.
        Success = 2,
        //
        // Summary:
        //     The copy operation has been aborted.
        Aborted = 3,
        //
        // Summary:
        //     The copy operation encountered an error.
        Failed = 4
    }

    internal class StorageCopyState
    {
        public StorageCopyState(Microsoft.WindowsAzure.Storage.Blob.CopyState blobCopyState)
        {
            this.CopyId = blobCopyState.CopyId;
            this.CompletionTime = blobCopyState.CompletionTime;
            this.SetStatus(blobCopyState.Status);
            this.Source = blobCopyState.Source;
            this.BytesCopied = blobCopyState.BytesCopied;
            this.TotalBytes = blobCopyState.TotalBytes;
            this.StatusDescription = blobCopyState.StatusDescription;
            this.DestinationSnapshotTime = blobCopyState.DestinationSnapshotTime;
        }

        public StorageCopyState(Microsoft.WindowsAzure.Storage.File.CopyState fileCopyState)
        {
            this.CopyId = fileCopyState.CopyId;
            this.CompletionTime = fileCopyState.CompletionTime;
            this.SetStatus(fileCopyState.Status);
            this.Source = fileCopyState.Source;
            this.BytesCopied = fileCopyState.BytesCopied;
            this.TotalBytes = fileCopyState.TotalBytes;
            this.StatusDescription = fileCopyState.StatusDescription;
            this.DestinationSnapshotTime = fileCopyState.DestinationSnapshotTime;
        }

        private void SetStatus(Microsoft.WindowsAzure.Storage.Blob.CopyStatus blobCopyStatus)
        {
            switch (blobCopyStatus)
            {
                case Blob.CopyStatus.Invalid:
                    this.Status = StorageCopyStatus.Invalid;
                    break;
                case Blob.CopyStatus.Pending:
                    this.Status = StorageCopyStatus.Pending;
                    break;
                case Blob.CopyStatus.Success:
                    this.Status = StorageCopyStatus.Success;
                    break;
                case Blob.CopyStatus.Aborted:
                    this.Status = StorageCopyStatus.Aborted;
                    break;
                case Blob.CopyStatus.Failed:
                    this.Status = StorageCopyStatus.Failed;
                    break;
                default:
                    this.Status = StorageCopyStatus.Invalid;
                    break;
            }
        }

        private void SetStatus(Microsoft.WindowsAzure.Storage.File.CopyStatus fileCopyStatus)
        {
            switch (fileCopyStatus)
            {
                case File.CopyStatus.Invalid:
                    this.Status = StorageCopyStatus.Invalid;
                    break;
                case File.CopyStatus.Pending:
                    this.Status = StorageCopyStatus.Pending;
                    break;
                case File.CopyStatus.Success:
                    this.Status = StorageCopyStatus.Success;
                    break;
                case File.CopyStatus.Aborted:
                    this.Status = StorageCopyStatus.Aborted;
                    break;
                case File.CopyStatus.Failed:
                    this.Status = StorageCopyStatus.Failed;
                    break;
                default:
                    this.Status = StorageCopyStatus.Invalid;
                    break;
            }
        }

        //
        // Summary:
        //     Gets the ID of the copy operation.
        public string CopyId { get; private set; }
        //
        // Summary:
        //     Gets the time the copy operation completed, and indicates whether completion
        //     was due to a successful copy, the cancelling of the operation, or a failure.
        public DateTimeOffset? CompletionTime { get; private set; }
        //
        // Summary:
        //     Gets the status of the copy operation.
        public StorageCopyStatus Status { get; private set; }
        //
        // Summary:
        //     Gets the source URI of a copy operation.
        public Uri Source { get; private set; }
        //
        // Summary:
        //     Gets the number of bytes copied in the operation so far.
        public long? BytesCopied { get; private set; }
        //
        // Summary:
        //     Gets the total number of bytes in the source of the copy.
        public long? TotalBytes { get; private set; }
        //
        // Summary:
        //     Gets the description of the current status, if any.
        public string StatusDescription { get; private set; }
        //
        // Summary:
        //     Gets the incremental destination snapshot time for the latest incremental copy,
        //     if present.
        public DateTimeOffset? DestinationSnapshotTime { get; private set; }
    }
}
