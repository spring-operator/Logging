﻿// Copyright 2017 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;

namespace Steeltoe.Extensions.Logging
{
    public static class DynamicLoggingBuilder
    {
        public static ILoggingBuilder AddDynamicConsole(this ILoggingBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddFilter<DynamicLoggerProvider>(null, LogLevel.Trace);
            builder.Services.AddSingleton<ILoggerProvider, DynamicLoggerProvider>();
            return builder;
        }

        public static ILoggingBuilder AddDynamicConsole(this ILoggingBuilder builder, IConfiguration configuration)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var settings = new ConsoleLoggerSettings().FromConfiguration(configuration);
            builder.AddFilter<DynamicLoggerProvider>(null, LogLevel.Trace);
            builder.AddProvider(new DynamicLoggerProvider(settings));
            return builder;
        }
    }
}
