using System;
using System.ComponentModel;

namespace Zynas.Control.Common
{
    /// <summary>
    /// 
    /// ref:
    /// http://stackoverflow.com/questions/6817107/abstract-usercontrol-inheritance-in-visual-studio-designer
    /// http://wonkitect.wordpress.com/2008/06/20/using-visual-studio-whidbey-to-design-abstract-forms/
    /// </summary>
    /// <typeparam name="TAbstract"></typeparam>
    /// <typeparam name="TBase"></typeparam>
    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract)) { return typeof(TBase); }

            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract)) { objectType = typeof(TBase); }

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}
