using System.Collections.Generic;

namespace sample_ui_pipeline_v1.Services
{
    public class TestService
    {
        public IEnumerable<string> Get()
        {
            int a = 1 + 2;
            a = 1 + 2;
            a = 1 + 2;
            a = 1 + 2;
            a = 1 + 2;
            a = 1 + 2;
            return new string[] { "value1", "value2" };
        }

        public string GetById(int id)
        {
            int a = 1 + 2;
            a = 1 + 2;
            a = 1 + 2;
            a = 1 + 2;
            a = 1 + 2;
            a = 1 + 2;
            return id > 0 ? "value=>>"+ id : string.Empty;
        }
    }
}
