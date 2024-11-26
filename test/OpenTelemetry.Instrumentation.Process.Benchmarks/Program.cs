// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0
using BenchmarkDotNet.Running;

namespace OpenTelemetry.Instrumentation.Process.Benchmarks;

internal class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ProcessBenchMark>();
    }
}
