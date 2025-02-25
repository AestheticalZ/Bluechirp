﻿#region License Information (GPLv3)
// Bluechirp - A modern, native client for the Mastodon social media.
// Copyright (C) 2023 Analog Feelings and contributors.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
#endregion

using Bluechirp.Library.Services.Environment;
using System;
using Windows.ApplicationModel;

namespace Bluechirp.Services.Environment;

/// <summary>
/// Implements an application and system information helper service.
/// </summary>
internal class InfoService : IInfoService
{
    /// <inheritdoc/>
    public Version AppVersion { get; init; }

    public InfoService()
    {
        Package package = Package.Current;
        PackageVersion version = package.Id.Version;

        this.AppVersion = new Version(version.Major, version.Minor, version.Build);
    }
}
