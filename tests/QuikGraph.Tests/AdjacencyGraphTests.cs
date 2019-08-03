using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;

namespace QuikGraph.Tests
{
    /// <summary>
    /// Tests for <see cref="AdjacencyGraph{TVertex,TEdge}"/>.
    /// </summary>
    [TestFixture]
    internal class AdjacencyGraphTests
    {
        #region Helpers

        public bool AddEdge<TVertex, TEdge>([NotNull] AdjacencyGraph<TVertex, TEdge> target, [NotNull] TEdge edge)
            where TEdge : IEdge<TVertex>
        {
            // TODO: add assertions to method AdjacencyGraphTVertexTEdgeTest.AddEdge(AdjacencyGraph`2<!!0,!!1>, !!1)
            try
            {
                return target.AddEdge(edge);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        #endregion

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException97()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[0];
                    AdjacencyGraph<int, Edge<int>> adjacencyGraph = AdjacencyGraphFactory.Create(false, keyValuePairs);
                    AddEdge(adjacencyGraph, null);
                });
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException72()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[1];
                    AdjacencyGraph<int, Edge<int>> adjacencyGraph = AdjacencyGraphFactory.Create(false, keyValuePairs);
                    AddEdge(adjacencyGraph, null);
                });
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException200()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    KeyValuePair<int, int>[] keyValuePairs = new KeyValuePair<int, int>[0];
                    AdjacencyGraph<int, Edge<int>> adjacencyGraph = AdjacencyGraphFactory.Create(false, keyValuePairs);
                    Edge<int> edge = EdgeFactory.Create(0, 0);
                    AddEdge(adjacencyGraph, edge);
                });
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException315()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    var keyValuePairs = new KeyValuePair<int, int>[2];
                    var s0 = new KeyValuePair<int, int>(1048578, 840056837);
                    keyValuePairs[0] = s0;
                    var s1 = new KeyValuePair<int, int>(273287168, 273287168);
                    keyValuePairs[1] = s1;
                    AdjacencyGraph<int, Edge<int>> adjacencyGraph = AdjacencyGraphFactory.Create(false, keyValuePairs);
                    AddEdge(adjacencyGraph, null);
                });
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException569()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    var keyValuePairs = new KeyValuePair<int, int>[2];
                    var s0 = new KeyValuePair<int, int>(-2097099498, 50384150);
                    keyValuePairs[0] = s0;
                    var s1 = new KeyValuePair<int, int>(-2097099498, -2097099498);
                    keyValuePairs[1] = s1;
                    AdjacencyGraph<int, Edge<int>> adjacencyGraph = AdjacencyGraphFactory.Create(false, keyValuePairs);
                    AddEdge(adjacencyGraph, null);
                });
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException966()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    var keyValuePairs = new KeyValuePair<int, int>[3];
                    var s0 = new KeyValuePair<int, int>(1048578, 840056837);
                    keyValuePairs[0] = s0;
                    var s1 = new KeyValuePair<int, int>(273287168, 273287168);
                    keyValuePairs[1] = s1;
                    var s2 = new KeyValuePair<int, int>(-1, -1);
                    keyValuePairs[2] = s2;
                    AdjacencyGraph<int, Edge<int>> adjacencyGraph = AdjacencyGraphFactory.Create(false, keyValuePairs);
                    AddEdge(adjacencyGraph, null);
                });
        }

        [Test]
        [Ignore("To fix later")]
        public void AddEdge55()
        {
            var keyValuePairs = new KeyValuePair<int, int>[2];
            var s0 = new KeyValuePair<int, int>(36014113, 1781006400);
            keyValuePairs[0] = s0;
            var s1 = new KeyValuePair<int, int>(708135361, 708135361);
            keyValuePairs[1] = s1;
            AdjacencyGraph<int, Edge<int>> adjacencyGraph = AdjacencyGraphFactory.Create(false, keyValuePairs);
            Assert.IsFalse(AddEdge(adjacencyGraph, null), "Operation result.");
            Assert.IsNotNull(adjacencyGraph, "Is null.");
            Assert.IsTrue(adjacencyGraph.IsDirected, "Direction checking.");
            Assert.IsFalse(adjacencyGraph.AllowParallelEdges, "Parallel edges checking.");
            Assert.AreEqual(-1, adjacencyGraph.EdgeCapacity, "Edge capacity checking.");
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdge791()
        {
            var keyValuePairs = new KeyValuePair<int, int>[2];
            var adjacencyGraph = AdjacencyGraphFactory.Create(true, keyValuePairs);
            Assert.IsTrue(AddEdge(adjacencyGraph, null));
            Assert.IsNotNull(adjacencyGraph);
            Assert.IsTrue(adjacencyGraph.IsDirected);
            Assert.IsTrue(adjacencyGraph.AllowParallelEdges);
            Assert.AreEqual(-1, adjacencyGraph.EdgeCapacity);
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException235()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    var adjacencyGraph = new AdjacencyGraph<int, SEdge<int>>(false, 0, 0);
                    AddEdge(adjacencyGraph, default);
                });
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException82()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    var adjacencyGraph = new AdjacencyGraph<int, SEdge<int>>(false, int.MinValue, 0);
                    AddEdge(adjacencyGraph, default);
                });
        }

        [Test]
        [Ignore("Was already ignored")]
        public void AddEdgeThrowsContractException811()
        {
            QuikGraphAssert.ThrowsContractException(
                () =>
                {
                    var adjacencyGraph = new AdjacencyGraph<int, SEdge<int>>(false, 1, 0);
                    AddEdge(adjacencyGraph, default);
                });
        }

        [Test]
        [Ignore("Was already ignored")]
        [Description("The test state was: path bounds exceeded")]
        public void AddEdge01()
        {
            var adjacencyGraph = new AdjacencyGraph<int, SEdge<int>>(false, 15334, 0);
            AddEdge(adjacencyGraph, default);
        }
    }
}