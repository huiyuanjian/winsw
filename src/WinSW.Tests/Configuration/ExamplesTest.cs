﻿using System;
using System.IO;
using System.Xml;
using WinSW.Tests.Util;
using Xunit;

namespace WinSW.Tests.Configuration
{
    /// <summary>
    /// Tests example configuration files.
    /// The test uses a relative path to example files, which is based on the current project structure.
    /// </summary>
    public class ExamplesTest
    {
        [Fact]
        public void AllOptionsConfigShouldDeclareDefaults()
        {
            XmlServiceConfig config = Load("complete");

            Assert.Equal("myapp", config.Name);
            Assert.Equal("%BASE%\\myExecutable.exe", config.Executable);

            ServiceConfigAssert.AssertAllOptionalPropertiesAreDefault(config);
        }

        [Fact]
        public void MinimalConfigShouldDeclareDefaults()
        {
            XmlServiceConfig config = Load("minimal");

            Assert.Equal("myapp", config.Name);
            Assert.Equal("%BASE%\\myExecutable.exe", config.Executable);

            ServiceConfigAssert.AssertAllOptionalPropertiesAreDefault(config);
        }

        private static XmlServiceConfig Load(string exampleName)
        {
            string directory = Layout.RepositoryRoot;

            string path = Path.Combine(directory, $@"samples\sample-{exampleName}.xml");
            Assert.True(File.Exists(path));

            XmlDocument dom = new XmlDocument();
            dom.Load(path);
            return new XmlServiceConfig(dom);
        }
    }
}
