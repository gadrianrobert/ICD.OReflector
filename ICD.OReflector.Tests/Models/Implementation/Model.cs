﻿using System;
using System.ComponentModel.Design;
using ICD.OReflector.Tests.Models.Abstract;
using ICD.OReflector.Tests.Models.Attributes;

namespace ICD.OReflector.Tests.Models.Implementation
{
    [Custom]
    public class Model : AbstractModel
    {
        public Model()
        {
            var test = false;
        }

        public event ChangedEventHandler OnChanged;

        [Custom]
        public override int Id { get; set; }
    }

    public delegate void ChangedEventHandler(object sender, EventArgs args);
}
