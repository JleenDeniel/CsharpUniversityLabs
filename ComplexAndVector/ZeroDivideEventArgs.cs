using System;

namespace ComplexAndVector {
    class ZeroDivideEventArgs : EventArgs {
        public object _dividend { get; set; }
        public object _divider { get; set; }

        public ZeroDivideEventArgs(object dividend, object divider) {
            _dividend = dividend;
            _divider = divider;
        }
    }
}
