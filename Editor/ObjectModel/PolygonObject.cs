using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml.Linq;
using UnityEngine;

namespace UnityTiled
{
    public class PolygonObject : Object
    {
        public ReadOnlyCollection<Vector2> points { get; private set; }

        internal PolygonObject(XElement element)
            : base(element)
        {
            var points = new List<Vector2>();

            string pointsData = element.Element("polygon").Attribute("points").StringValue();
            foreach (string p in pointsData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)) {
                var pSplit = p.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                points.Add(new Vector2(float.Parse(pSplit[0], CultureInfo.InvariantCulture),
                                       float.Parse(pSplit[1], CultureInfo.InvariantCulture)));
            }

            this.points = new ReadOnlyCollection<Vector2>(points);
        }
    }
}
