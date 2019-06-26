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
using Cube.Images.Icons;
using Cube.Mixin.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cube.Pdf.Pages
{
    /* --------------------------------------------------------------------- */
    ///
    /// IconCollection
    ///
    /// <summary>
    /// Represents the collection of icons.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class IconCollection
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// IconCollection
        ///
        /// <summary>
        /// Initializes a new instance of the IconCollection class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public IconCollection()
        {
            ImageList = new ImageList
            {
                ImageSize  = new Size(16, 16),
                ColorDepth = ColorDepth.Depth32Bit,
            };
            ImageList.Images.Add(GetDefaultIcon());
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// ImageList
        ///
        /// <summary>
        /// Gets the ImageList object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ImageList ImageList { get; }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Add
        ///
        /// <summary>
        /// Add a new icon that is associated with the specified file.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public int Add(File file)
        {
            var icon = file.GetIcon(IconSize.Small);
            if (icon == null) return 0;

            var extension = file.Extension.ToLower();
            if (_map.ContainsKey(extension)) return _map[extension];

            var index = ImageList.Images.Count;
            ImageList.Images.Add(icon);
            _map.Add(extension, index);
            return index;
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// GetDefaultIcon
        ///
        /// <summary>
        /// Gets the default icon.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private Icon GetDefaultIcon()
        {
            try { return IconFactory.Create(StockIcons.DocumentNotAssociated, IconSize.Small); }
            catch (Exception err)
            {
                this.LogError(err);
                return Properties.Resources.NotAssociated;
            }
        }

        #endregion

        #region Fields
        private readonly Dictionary<string, int> _map = new Dictionary<string, int>();
        #endregion
    }
}