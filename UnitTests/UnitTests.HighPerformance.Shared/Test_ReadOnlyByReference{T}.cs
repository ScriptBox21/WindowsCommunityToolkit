﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.CompilerServices;
using Microsoft.Toolkit.HighPerformance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.HighPerformance
{
    [TestClass]
    public class Test_ReadOnlyByReferenceT
    {
        [TestCategory("ReadOnlyByReferenceT")]
        [TestMethod]
#if NETCOREAPP2_1
        public void Test_ByReferenceOfT_CreateByReferenceOfT()
        {
            var model = new ReadOnlyFieldOwner();
            var reference = new ReadOnlyByReference<int>(model, model.Value);

            Assert.IsTrue(Unsafe.AreSame(ref Unsafe.AsRef(model.Value), ref Unsafe.AsRef(reference.Value)));
        }

        /// <summary>
        /// A dummy model that owns an <see cref="int"/> field.
        /// </summary>
        private sealed class ReadOnlyFieldOwner
        {
            public readonly int Value = 1;
        }
#else
        public void Test_ByReferenceOfT_CreateByReferenceOfT()
        {
            int value = 1;
            var reference = new ReadOnlyByReference<int>(value);

            Assert.IsTrue(Unsafe.AreSame(ref value, ref Unsafe.AsRef(reference.Value)));

        }
#endif
    }
}
