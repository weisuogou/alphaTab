﻿/*
 * This file is part of alphaTab.
 * Copyright © 2018, Daniel Kuschny and Contributors, All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or at your option any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */

using AlphaTab.Collections;
using AlphaTab.Model;
using AlphaTab.Platform;
using AlphaTab.Rendering.Staves;

namespace AlphaTab.Rendering.Glyphs
{
    class TabBeatContainerGlyph : BeatContainerGlyph
    {
        private TabBendGlyph _bend;

        public TabBeatContainerGlyph(Beat beat, VoiceContainerGlyph voiceContainer)
            : base(beat, voiceContainer)
        {
        }

        public override void DoLayout()
        {
            base.DoLayout();
            if (_bend != null)
            {
                _bend.Renderer = Renderer;
                _bend.DoLayout();
                UpdateWidth();
            }
        }

        protected override void CreateTies(Note n)
        {
            if (!n.IsVisible) return;

            var renderer = (TabBarRenderer)Renderer;
            if (n.IsTieOrigin && renderer.ShowTiedNotes && n.TieDestination.IsVisible)
            {
                var tie = new TabTieGlyph(n, n.TieDestination, false);
                Ties.Add(tie);
            }
            if (n.IsTieDestination && renderer.ShowTiedNotes)
            {
                var tie = new TabTieGlyph(n.TieOrigin, n, false, true);
                Ties.Add(tie);
            }

            if (n.SlurOrigin != null)
            {
                var tie = new TabSlurGlyph(n);
                Ties.Add(tie);
            }

            if (n.SlideType != SlideType.None)
            {
                var l = new TabSlideLineGlyph(n.SlideType, n, this);
                Ties.Add(l);
            }

            if (n.HasBend)
            {
                if (_bend == null)
                {
                    _bend = new TabBendGlyph(n.Beat);
                    _bend.Renderer = Renderer;
                    Ties.Add(_bend);
                }
                _bend.AddBends(n);
            }
        }
    }
}
