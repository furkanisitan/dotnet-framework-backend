using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Shop.Business.Aspects.Postsharp.PerformanceAspects
{
    /// <summary>
    /// It works when the working time of the method exceeds a certain time.
    /// </summary>
    [PSerializable]
    public class PerformanceCounterAttribute : OnMethodBoundaryAspect
    {
        private int _interval;
        [NonSerialized]
        private Stopwatch _stopwatch;

        /// <param name="interval">Time limit. (default => 5 seconds)</param>
        public PerformanceCounterAttribute(int interval = 5)
        {
            _interval = interval;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
                Debug.WriteLine($"Performance: {args.Method.DeclaringType?.FullName}.{args.Method.Name} ->> {_stopwatch.Elapsed.TotalSeconds}");
            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}
