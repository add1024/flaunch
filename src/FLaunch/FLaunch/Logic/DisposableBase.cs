using System;

namespace FLaunch.Logic
{
    /// <summary>
    /// IDisposable support base
    /// </summary>
    internal abstract class DisposableBase : IDisposable
    {
        private bool _disposed;
        /// <summary>
        /// Disposed flag
        /// </summary>
        protected bool Disposed => _disposed;

        /// <summary>
        /// Dispose(for User)
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose(for override)
        /// </summary>
        /// <param name="disposing">intentional</param>
        protected virtual void Dispose(bool disposing)
        {
            _disposed = true;
        }

        /// <summary>
        /// forgotten
        /// </summary>
        ~DisposableBase()
        {
            Dispose(false);
        }

        ////for subclass
        ///// <summary>
        ///// Dispose
        ///// </summary>
        ///// <param name="disposing">intentional</param>
        //protected override void Dispose(bool disposing)
        //{
        //    try
        //    {
        //        if (Disposed) return;
        //        if (disposing)
        //        {
        //            //managed

        //        }
        //        //unmanaged

        //    }
        //    finally
        //    {
        //        base.Dispose(disposing);
        //    }
        //}
    }
}
