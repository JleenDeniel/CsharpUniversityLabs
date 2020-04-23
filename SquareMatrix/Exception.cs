using System;
using System.Collections.Generic;
using System.Text;

namespace SquareMatrix {

    [Serializable]
    public class DegenerateMatrixException : Exception {
        public DegenerateMatrixException() { }
        public DegenerateMatrixException(string message) : base(message) { }
        public DegenerateMatrixException(string message, Exception inner) : base(message, inner) { }
        protected DegenerateMatrixException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}