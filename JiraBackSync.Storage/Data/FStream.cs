using System.IO;

namespace JiraBackSync.Storage.Data
{
    internal class FStream : MemoryStream
    {
        protected override void Dispose(bool disposing)
        {
            InternalFlush();
            base.Dispose(disposing);
        }

        public override void Flush()
        {
            InternalFlush();
        }

        private void InternalFlush()
        {
            /* reset back to the beginning .. */
            Seek(0, SeekOrigin.Begin);
        }
    }
}