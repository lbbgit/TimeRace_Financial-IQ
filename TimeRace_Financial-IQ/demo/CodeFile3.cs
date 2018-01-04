public class CodeFile3
{
    public void test()
    {
        string str=" hello world";
        string[] strList = { str };
        testParameter(" hello world");
        //testParameterLists({ str });//error
        //testParameterLists({" hello world "});//error
        testParameterLists(strList);
        testParameterLists(new string[] { str });

    }
    public void testParameter(string str) { }
    public void testParameterLists(string[] str) { }
}