using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace NetEscapades.Configuration.Yaml
{
    /// <summary>
    /// A YAML file based <see cref="FileConfigurationProvider"/>.
    /// </summary>
    public class YamlConfigurationProvider : FileConfigurationProvider
    {
        public YamlConfigurationProvider(YamlConfigurationSource source) : base(source) { }

        public override void Load(Stream stream)
        {
            var parser = new YamlConfigurationFileParser();
            try
            {
                Data = parser.Parse(stream);
            }
            catch (Exception e)
            {
                throw new FormatException(Resources.FormatError_YamlParseError(e));
            }
        }
    }
}
