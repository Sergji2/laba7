class Calculator<T>
{
    public delegate T AdditionDelegate(T a, T b);
    public delegate T SubtractionDelegate(T a, T b);
    public delegate T MultiplicationDelegate(T a, T b);
    public delegate T DivisionDelegate(T a, T b);

    public T Add(T a, T b, AdditionDelegate add)
    {
        return add(a, b);
    }

    public T Subtract(T a, T b, SubtractionDelegate subtract)
    {
        return subtract(a, b);
    }

    public T Multiply(T a, T b, MultiplicationDelegate multiply)
    {
        return multiply(a, b);
    }

    public T Divide(T a, T b, DivisionDelegate divide)
    {
        return divide(a, b);
    }
}