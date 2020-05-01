using System.Collections;
using System.Collections.Generic;
using DataBindChange;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PropertyTest
    {
        struct MyStruct
        {
            public string str;

            public override string ToString()
            {
                return str;
            }
        }

        class MyClass
        {
            public string str;

            public override string ToString()
            {
                return str;
            }
        }

        // A Test behaves as an ordinary method
        [Test]
        public void PropertyTestSimplePasses()
        {
            Property<bool> b0 = new Property<bool>(false, (x) => { Debug.Log(x); });
            b0.Val = true;
            Assert.IsTrue(b0 == true);

            Property<bool> b1 = new Property<bool>(false, (x) => { Debug.Log(x); }, true);
            b1.Val = false;
            Assert.IsTrue(b1.Val == false);

            Property<MyStruct> s0 = new Property<MyStruct>(act: (x) => { Debug.Log(x); });
            s0.Val = new MyStruct() {str = "asdasd"};
            Assert.IsTrue(s0.Val.str == "asdasd");


            Property<MyClass> c0 = new Property<MyClass>(act: (x) => { Debug.Log(x); });
            var cls = new MyClass() { str = "aaaa" };
            c0.Val = cls;
            Assert.IsTrue(c0.Val == cls);

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        //        [UnityTest]
        //        public IEnumerator PropertyTestWithEnumeratorPasses()
        //        {
        //            // Use the Assert class to test conditions.
        //            // Use yield to skip a frame.
        //            yield return null;
        //        }
    }
}