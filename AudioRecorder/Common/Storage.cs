using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecorder
{
    internal class Storage
    {
        private readonly StorageSchema Schema;
        private byte[] SchemaHeader = new byte[0];
        private byte[] Header = new byte[0];
        private int CurrentIndex = 0;
        public Storage(StorageSchema schema)
        {
            Schema = schema;            
        }
        private void ParseSchema()
        {
            Sanity.Requires(Schema.ColumnCount == Schema.ColumnNames.Length, "Schema name count mismatches.");
            Sanity.Requires(Schema.ColumnCount == Schema.ColumnTypes.Length, "Schema type count mismatches.");            
        }
    }    

    internal struct StorageSchema
    {
        public int ChunkSize { get; }
        public int ColumnCount { get;}
        public string[] ColumnNames { get; }
        public ValueType[] ColumnTypes { get; }
    }

    internal enum ValueType
    {
        Str = 0,
        Bin = 1,
    }
}
