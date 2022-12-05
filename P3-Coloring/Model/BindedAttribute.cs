namespace P3_Coloring.Model
{
    public class BindedAttribute<T>
    {
        private Func<T, T> _getter = (_) => _;
        private Func<T, T> _setter = (_) => _;

        private T _value;
        public T Value { get => _getter(_value); set => _value = _setter(value); }

        public BindedAttribute(T initialValue, Func<T, T> getter, Func<T, T> setter)
        {
            _getter = getter;
            _setter = setter;
            _value = initialValue;
            Value = initialValue;
        }

        public BindedAttribute(T initialValue, Func<T, T> setter)
        {
            _setter = setter;
            _value = initialValue;
            Value = initialValue;
        }

        public BindedAttribute(T initialValue)
        {
            _value = initialValue;
            Value = initialValue;
        }

        public static implicit operator T(BindedAttribute<T> bindedAttribute)
        {
            return bindedAttribute.Value;
        }

        public static implicit operator BindedAttribute<T>(T bindedAttribute)
        {
            return new BindedAttribute<T>(bindedAttribute);
        }
    }
}
