using Antlr.Runtime;
using Graphviz4Net.Dot;
using Graphviz4Net.Dot.AntlrParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZTP
{
    public class GraphParser
    {
        public DotGraph<int> Run(string path)
        {
            using StreamReader streamReader = new StreamReader(path);
            ANTLRStringStream antlrStream = new ANTLRStringStream(streamReader.ReadToEnd());
            DotGrammarLexer lexer = new DotGrammarLexer(antlrStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            DotGrammarParser parser = new DotGrammarParser(tokenStream);
            IntDotGraphBuilder builder = new IntDotGraphBuilder();
            parser.Builder = builder;
            parser.dot();
            return builder.DotGraph;
        }
    }
}
