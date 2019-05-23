﻿/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
/* ------------------------------------------------------------------------- */
using Cube.Mixin.String;

namespace Cube.Pdf.Converter
{
    /* --------------------------------------------------------------------- */
    ///
    /// GlobalSettings
    ///
    /// <summary>
    /// Represents the global settings of the application.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    internal static class GlobalSettings
    {
        /* ----------------------------------------------------------------- */
        ///
        /// GlobalSettings
        ///
        /// <summary>
        /// Invokes the global settings.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        static GlobalSettings()
        {
            Locale.Configure(e =>
            {
                var src = e.ToCultureInfo();
                var cmp = Properties.Resources.Culture?.Name;
                if (cmp.HasValue() && cmp.FuzzyEquals(src.Name)) return false;
                Properties.Resources.Culture = src;
                return true;
            });
        }
    }
}
