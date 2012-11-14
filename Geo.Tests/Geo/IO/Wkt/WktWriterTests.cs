﻿using NUnit.Framework;
using Geo.IO.Wkt;
using Geo.Geometries;

namespace Geo.Tests.Geo.IO.Wkt
{
    [TestFixture]
    public class WktWriterTests
    {
        [Test]
        public void Point()
        {
            var writer = new WktWriter();

            var xy = writer.Write(new Point(65.9, 0));
            Assert.AreEqual("POINT (0 65.9)", xy);

            var xyz = writer.Write(new Point(65.9, 0, 5));
            Assert.AreEqual("POINT Z (0 65.9 5)", xyz);

            var xym = writer.Write(new Point(65.9, 0, double.NaN, 5));
            Assert.AreEqual("POINT M (0 65.9 5)", xym);

            var xyzm = writer.Write(new Point(65.9, 0, 4, 5));
            Assert.AreEqual("POINT ZM (0 65.9 4 5)", xyzm);

            var empty = writer.Write(global::Geo.Geometries.Point.Empty);
            Assert.AreEqual("POINT EMPTY", empty);
        }

        [Test]
        public void LineString()
        {
            var writer = new WktWriter();

            var xy = writer.Write(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5)));
            Assert.AreEqual("LINESTRING (0 65.9, -34.5 9)", xy);

            var empty = writer.Write(global::Geo.Geometries.LineString.Empty);
            Assert.AreEqual("LINESTRING EMPTY", empty);
        }

        [Test]
        public void Polygon()
        {
            var writer = new WktWriter();

            var xy = writer.Write(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))));
            Assert.AreEqual("POLYGON ((0 65.9, -34.5 9, -20 40, 0 65.9))", xy);

            var empty = writer.Write(global::Geo.Geometries.Polygon.Empty);
            Assert.AreEqual("POLYGON EMPTY", empty);
        }

        [Test]
        public void MultiPoint()
        {
            var writer = new WktWriter();

            var brackets = writer.Write(new MultiPoint(new Point(65.9, 0), new Point(9, -34.5), new Point(40, -20), new Point(65.9, 0)));
            Assert.AreEqual("MULTIPOINT ((0 65.9), (-34.5 9), (-20 40), (0 65.9))", brackets);

            var empty = writer.Write(new MultiPoint());
            Assert.AreEqual("MULTIPOINT EMPTY", empty);
        }

        [Test]
        public void MultiLineString()
        {
            var writer = new WktWriter();

            var one = writer.Write(new MultiLineString(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))));
            Assert.AreEqual("MULTILINESTRING ((0 65.9, -34.5 9, -20 40, 0 65.9))", one);


            var two = writer.Write(new MultiLineString(new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)), new LineString(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))));
            Assert.AreEqual("MULTILINESTRING ((0 65.9, -34.5 9, -20 40, 0 65.9), (0 65.9, -34.5 9, -20 40, 0 65.9))", two);

            var empty = writer.Write(new MultiLineString());
            Assert.AreEqual("MULTILINESTRING EMPTY", empty);
        }

        [Test]
        public void MultiPolygon()
        {
            var writer = new WktWriter();

            var one = writer.Write(new MultiPolygon(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)))));
            Assert.AreEqual("MULTIPOLYGON (((0 65.9, -34.5 9, -20 40, 0 65.9)))", one);


            var two = writer.Write(new MultiPolygon(new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0))), new Polygon(new LinearRing(new Coordinate(65.9, 0), new Coordinate(9, -34.5), new Coordinate(40, -20), new Coordinate(65.9, 0)))));
            Assert.AreEqual("MULTIPOLYGON (((0 65.9, -34.5 9, -20 40, 0 65.9)), ((0 65.9, -34.5 9, -20 40, 0 65.9)))", two);

            var empty = writer.Write(new MultiPolygon());
            Assert.AreEqual("MULTIPOLYGON EMPTY", empty);
        }
    }
}