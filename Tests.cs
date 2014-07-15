using System;
using System.IO;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            using (var fs = new FileStream("TestDocument.pdf", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                // Calculate hash using method 1
                var hash = ITG.Utilities.MD5.GetHash(fs);

                // Reset the stream to the start of the file
                fs.Position = 0;

                // Calculate hash using method 2
                var hashV2 = ITG.Utilities.MD5.GetHashV2(fs);

                // Assert method 1 calculated the correct hash
                Assert.That(hash.Equals("277e8c8b4417b64ffd65a4e769fee246", StringComparison.InvariantCultureIgnoreCase));

                // Assert method 2 calculated the correct hash
                Assert.That(hashV2.Equals("277e8c8b4417b64ffd65a4e769fee246", StringComparison.InvariantCultureIgnoreCase));

                // Assert outputs of method 1 and method 2 are equal
                Assert.That(hash.Equals(hashV2, StringComparison.InvariantCultureIgnoreCase));
            }
        }
    }
}
