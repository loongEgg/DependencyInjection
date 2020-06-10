namespace LoongEgg.DependencyInjection
{
    /// <summary>
    /// 用于获取各种实例的依赖反转工具
    /// </summary>
    public static class IoC
    {
        public static Container Container { get; } = new Container();
    }
}
