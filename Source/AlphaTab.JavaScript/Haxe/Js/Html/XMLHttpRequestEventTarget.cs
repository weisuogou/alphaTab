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
using System;
using Phase.Attributes;

namespace Haxe.Js.Html
{
    [External]
    [Name("js.html.XMLHttpRequestEventTarget")]
    public class XMLHttpRequestEventTarget : EventTarget
    {
        [Name("onloadstart")] public Delegate OnLoadStart;
        [Name("onprogress")] public Delegate OnProgress;
        [Name("onabort")] public Delegate OnAbort;
        [Name("onerror")] public Delegate OnError;
        [Name("onload")] public Delegate OnLoad;
        [Name("ontimeout")] public Delegate OnTimeout;
        [Name("onloadend")] public Delegate OnLoadEnd;
    }
}