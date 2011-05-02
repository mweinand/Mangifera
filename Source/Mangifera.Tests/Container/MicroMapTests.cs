﻿using System;
using Mangifera.Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mangifera.Tests.Container
{
    [TestClass]
    public class MicroMapTests
    {
        [TestMethod]
        public void can_add_and_retrive_basic_class()
        {
            MicroMap.Initialize();
            MicroMap.Register<Interface1, Class1>();

            var instance = MicroMap.GetInstance<Interface1>();

            Assert.AreEqual(instance.GetType(), typeof (Class1));
        }

        [TestMethod]
        public void can_add_and_retrieve_static_class()
        {
            var staticClass = new Class1();

            MicroMap.Initialize();
            MicroMap.Register<Interface1>(staticClass);

            var instance = MicroMap.GetInstance<Interface1>();
            var instance2 = MicroMap.GetInstance<Interface1>();

            Assert.AreEqual(instance, staticClass);
            Assert.AreEqual(instance2, staticClass);
        }

        [TestMethod]
        public void can_add_and_retreive_from_func_definition()
        {
            MicroMap.Initialize();
            MicroMap.Register<Interface1>(x =>
                                              {
                                                  var class1 = new Class1();
                                                  return class1;
                                              });

            var instance = MicroMap.GetInstance<Interface1>();

            Assert.AreEqual(instance.GetType(), typeof(Class1));
        }

        [TestMethod]
        public void can_build_up_single_depenancy()
        {
            MicroMap.Initialize();
            MicroMap.Register<Interface1, Class1>();
            MicroMap.Register<Interface2, Class2>();

            var instance = MicroMap.GetInstance<Interface2>();

            Assert.AreEqual(instance.GetType(), typeof(Class2));

            Assert.AreEqual(instance.Class1.GetType(), typeof (Class1));
        }

        [TestMethod]
        public void builds_up_complex_dependancy()
        {
            MicroMap.Initialize();
            MicroMap.Register<Interface1, Class1>();
            MicroMap.Register<Interface2>(x => new Class2(x.GetInstance<Interface1>()));
            MicroMap.Register<Interface3, Class3>();

            var instance = MicroMap.GetInstance<Interface3>();

            Assert.AreEqual(instance.GetType(), typeof(Class3));

            Assert.AreEqual(instance.Class1.GetType(), typeof(Class1));
            Assert.AreEqual(instance.Class2.GetType(), typeof(Class2));
        }
    }

    public interface Interface1
    {
        void Test();
    }

    public class Class1 : Interface1
    {
        public void Test()
        {
            throw new NotImplementedException();
        }
    }

    public interface Interface2
    {
        Interface1 Class1 { get; }
        void Test2();
    }

    public class Class2 : Interface2
    {
        public Interface1 Class1 { get; private set; }

        public Class2(Interface1 class1)
        {
            Class1 = class1;
        }

        public void Test2()
        {
            Class1.Test();
        }
    }

    public interface Interface3
    {
        Interface1 Class1 { get; }
        Interface2 Class2 { get; }
    }

    public class Class3 : Interface3
    {
        public Interface1 Class1 { get; private set; }
        public Interface2 Class2 { get; private set; }

        public Class3(Interface1 i1, Interface2 i2)
        {
            Class1 = i1;
            Class2 = i2;
        }
    }
}