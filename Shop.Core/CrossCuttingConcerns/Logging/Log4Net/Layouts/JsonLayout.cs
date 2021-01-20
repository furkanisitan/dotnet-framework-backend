using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using Shop.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts.Helpers;
using System.IO;

namespace Shop.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        /// <summary>
        /// Properties in the loggingEvent object to be converted to json format.
        /// </summary>
        public string PropertyNames { get; set; } = "timestamp,messageObject,level,identity,loggerName,userName";

        public override void ActivateOptions() { }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var resolver = new CustomPropertiesContractResolver(PropertyNames.Split(','));
            var settings = new JsonSerializerSettings { ContractResolver = resolver };
            var serializableLoggingEvent = new SerializableLoggingEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(serializableLoggingEvent, settings);
            writer.WriteLine(json);
        }
    }
}
