﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageViewer.Models
{
    public class Image
    {
        public Image(string path, string desc)
        {
            Path = path;
            Description = desc;
        }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}