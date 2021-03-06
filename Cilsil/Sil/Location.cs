﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using Mono.Cecil.Cil;
using Newtonsoft.Json;

namespace Cilsil.Sil
{
    /// <summary>
    /// Source code location.
    /// </summary>
    [JsonObject]
    public class Location
    {
        /// <summary>
        /// The source code line number.
        /// </summary>
        [JsonProperty]
        public int Line { get; set; }

        /// <summary>
        /// The source code column number.
        /// </summary>
        [JsonProperty]
        public int Col { get; set; }

        /// <summary>
        /// The file with which this location is associated.
        /// </summary>
        [JsonProperty]
        public SourceFile SourceFile { get; set; }

        private static readonly Location DummyLocation = new Location()
        {
            SourceFile = SourceFile.Empty
        };

        /// <summary>
        /// Creates a location from a <see cref="SequencePoint"/>.
        /// </summary>
        /// <param name="sequencePoint">The sequence point storing information about the
        /// location.</param>
        /// <returns>The created location; if the input sequence point is null, this method returns
        /// a dummy location.</returns>
        public static Location FromSequencePoint(SequencePoint sequencePoint)
        {
            if (sequencePoint != null)
            {
                return new Location()
                {
                    Line = sequencePoint.StartLine,
                    Col = sequencePoint.StartColumn,
                    SourceFile = SourceFile.FromSequencePoint(sequencePoint),
                };
            }

            return DummyLocation;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Line {Line}";
    }
}
