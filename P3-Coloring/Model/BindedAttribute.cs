namespace P3_Coloring.Model
{
    public class BindedAttribute<T>
    {
        private Func<T, T> _getter;
        private Func<T, T> _setter;

        private T _value;
        public T Value { get => _getter(_value); set => _value = _setter(value); }

        public BindedAttribute(T initialValue, Func<T, T> getter, Func<T, T> setter)
        {
            _value = initialValue;
            Value = initialValue;
            _getter = getter;
            _setter = setter;
        }

        public static implicit operator T(BindedAttribute<T> bindedAttribute)
        {
            return bindedAttribute.Value;
        }
    }
}
