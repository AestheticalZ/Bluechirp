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

using System.Collections.Generic;

namespace Bluechirp.Library.Constants;

/// <summary>
/// Contains setting keys and default values.
/// </summary>
public static class SettingsConstants
{
    /// <summary>
    /// Used to remember the last user profile.
    /// </summary>
    public const string LAST_PROFILE_KEY = "LastProfile";

    /// <summary>
    /// Read-only dictionary containing all the default
    /// values for all setting keys.
    /// </summary>
    public static readonly IReadOnlyDictionary<string, object> Defaults = new Dictionary<string, object>()
    {
        { LAST_PROFILE_KEY, string.Empty }
    };
}