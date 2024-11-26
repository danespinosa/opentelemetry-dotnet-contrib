// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0
using BenchmarkDotNet.Attributes;
using OpenTelemetry.Metrics;

namespace OpenTelemetry.Instrumentation.Process.Benchmarks;

public class ProcessBenchMark
{
    [Benchmark]
    public void NoSnapshot()
    {
        var exportedItems = new List<Metric>();
        using var meterProvider = Sdk.CreateMeterProviderBuilder()
           .AddProcessInstrumentation()
           .AddInMemoryExporter(exportedItems, (c) =>
           {
               c.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds = 100;
           })
           .Build();

        meterProvider.ForceFlush();
    }

    [Benchmark]
    public void Snapshot()
    {
        var exportedItems = new List<Metric>();
        using var meterProvider = Sdk.CreateMeterProviderBuilder()
           .AddProcessInstrumentation()
           .AddInMemoryExporter(exportedItems, (c) =>
           {
               c.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds = 100;
           })
           .Build();

        meterProvider.ForceFlush();
    }
}
