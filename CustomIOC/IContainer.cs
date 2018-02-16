﻿using System;

namespace CustomIOC
{
    public interface IContainer
    {
        void Register<TTypeToResolve, TConcrete>();

        void Register<TTypeToResolve, TConcrete>(LifeCycle lifeCycle);

        TTypeToResolve Resolve<TTypeToResolve>();

        object Resolve(Type typeToResolve);
    }
}