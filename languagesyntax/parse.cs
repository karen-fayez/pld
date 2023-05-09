
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                       =  0, // (EOF)
        SYMBOL_ERROR                     =  1, // (Error)
        SYMBOL_WHITESPACE                =  2, // Whitespace
        SYMBOL_MINUS                     =  3, // '-'
        SYMBOL_MINUSMINUS                =  4, // '--'
        SYMBOL_EXCLAMEQ                  =  5, // '!='
        SYMBOL_LPAREN                    =  6, // '('
        SYMBOL_RPAREN                    =  7, // ')'
        SYMBOL_TIMES                     =  8, // '*'
        SYMBOL_COMMA                     =  9, // ','
        SYMBOL_DIV                       = 10, // '/'
        SYMBOL_COLON                     = 11, // ':'
        SYMBOL_AT                        = 12, // '@'
        SYMBOL_LBRACE                    = 13, // '{'
        SYMBOL_RBRACE                    = 14, // '}'
        SYMBOL_PLUS                      = 15, // '+'
        SYMBOL_PLUSPLUS                  = 16, // '++'
        SYMBOL_LT                        = 17, // '<'
        SYMBOL_LTEQ                      = 18, // '<='
        SYMBOL_EQ                        = 19, // '='
        SYMBOL_EQEQ                      = 20, // '=='
        SYMBOL_GT                        = 21, // '>'
        SYMBOL_GTEQ                      = 22, // '>='
        SYMBOL_AND                       = 23, // and
        SYMBOL_BEGIN                     = 24, // begin
        SYMBOL_BOOL                      = 25, // bool
        SYMBOL_CASE                      = 26, // case
        SYMBOL_DO                        = 27, // do
        SYMBOL_DONE                      = 28, // Done
        SYMBOL_ELSE                      = 29, // else
        SYMBOL_END                       = 30, // End
        SYMBOL_ENDFOR                    = 31, // EndFor
        SYMBOL_FLOAT                     = 32, // float
        SYMBOL_FOR                       = 33, // for
        SYMBOL_ID                        = 34, // Id
        SYMBOL_IF                        = 35, // if
        SYMBOL_IN                        = 36, // in
        SYMBOL_INT                       = 37, // int
        SYMBOL_LET                       = 38, // let
        SYMBOL_MAIN                      = 39, // main
        SYMBOL_MAKE                      = 40, // make
        SYMBOL_NUM                       = 41, // Num
        SYMBOL_OR                        = 42, // or
        SYMBOL_SHOW                      = 43, // show
        SYMBOL_STRING                    = 44, // string
        SYMBOL_TAKE                      = 45, // take
        SYMBOL_THEN                      = 46, // then
        SYMBOL_VAR                       = 47, // var
        SYMBOL_VOID                      = 48, // void
        SYMBOL_WHEN                      = 49, // when
        SYMBOL_WHILE                     = 50, // while
        SYMBOL_ADDOP                     = 51, // <addop>
        SYMBOL_ARGUMENTMINUSLIST         = 52, // <argument-list>
        SYMBOL_BODY                      = 53, // <body>
        SYMBOL_COMPARISONMINUSEXPRESSION = 54, // <comparison-expression>
        SYMBOL_COMPARISONMINUSOPERATOR   = 55, // <comparison-operator>
        SYMBOL_CONDITION                 = 56, // <condition>
        SYMBOL_CONDITIONS                = 57, // <conditions>
        SYMBOL_CONSTANTMINUSDECLARATION  = 58, // <constant-declaration>
        SYMBOL_DEC                       = 59, // <dec>
        SYMBOL_DOMINUSWHILEMINUSLOOP     = 60, // <do-while-loop>
        SYMBOL_ELSE2                     = 61, // <else>
        SYMBOL_EXPR                      = 62, // <expr>
        SYMBOL_EXPRESSION                = 63, // <expression>
        SYMBOL_FACTOR                    = 64, // <factor>
        SYMBOL_FORMINUSSTMT              = 65, // <for-stmt>
        SYMBOL_FUNCMINUSNAME             = 66, // <func-name>
        SYMBOL_FUNCTIONMINUSCALL         = 67, // <function-call>
        SYMBOL_FUNCTIONMINUSDEF          = 68, // <function-def>
        SYMBOL_ID2                       = 69, // <id>
        SYMBOL_IFMINUSSTMT               = 70, // <if-stmt>
        SYMBOL_INC                       = 71, // <inc>
        SYMBOL_INPUTMINUSSTMT            = 72, // <input-stmt>
        SYMBOL_INMINUSSTMT               = 73, // <in-stmt>
        SYMBOL_INMINUSSTMTS              = 74, // <in-stmts>
        SYMBOL_ITERABLEMINUSSTMT         = 75, // <iterable-stmt>
        SYMBOL_LOGICALMINUSOPERATOR      = 76, // <logical-operator>
        SYMBOL_MULOP                     = 77, // <mulop>
        SYMBOL_NUM2                      = 78, // <num>
        SYMBOL_PARAMETER                 = 79, // <parameter>
        SYMBOL_PARAMETERMINUSLIST        = 80, // <parameter-list>
        SYMBOL_PRINTMINUSSTMT            = 81, // <print-stmt>
        SYMBOL_SELECTIONMINUSSTMT        = 82, // <selection-stmt>
        SYMBOL_START                     = 83, // <start>
        SYMBOL_STATMENT                  = 84, // <statment>
        SYMBOL_STMTMINUSLIST             = 85, // <stmt-list>
        SYMBOL_SWITCHMINUSSTMT           = 86, // <switch-stmt>
        SYMBOL_TERM                      = 87, // <term>
        SYMBOL_TYPE                      = 88, // <type>
        SYMBOL_VALUE                     = 89, // <value>
        SYMBOL_VALUES                    = 90, // <values>
        SYMBOL_VARIABLEMINUSDECLARATION  = 91, // <variable-declaration>
        SYMBOL_WHENMINUSSTMT             = 92, // <when-stmt>
        SYMBOL_WHENMINUSSTMTS            = 93, // <when-stmts>
        SYMBOL_WHILEMINUSLOOP            = 94  // <while-loop>
    };

    enum RuleConstants : int
    {
        RULE_START_AT_MAIN_LBRACE_RBRACE                              =  0, // <start> ::= '@' main '{' <body> '}'
        RULE_BODY                                                     =  1, // <body> ::= <stmt-list>
        RULE_STMTLIST_COMMA                                           =  2, // <stmt-list> ::= <statment> ','
        RULE_STMTLIST_COMMA2                                          =  3, // <stmt-list> ::= <statment> ',' <stmt-list>
        RULE_STATMENT                                                 =  4, // <statment> ::= <variable-declaration>
        RULE_STATMENT2                                                =  5, // <statment> ::= <constant-declaration>
        RULE_STATMENT3                                                =  6, // <statment> ::= <selection-stmt>
        RULE_STATMENT4                                                =  7, // <statment> ::= <iterable-stmt>
        RULE_STATMENT5                                                =  8, // <statment> ::= <function-call>
        RULE_STATMENT6                                                =  9, // <statment> ::= <function-def>
        RULE_STATMENT7                                                = 10, // <statment> ::= <print-stmt>
        RULE_STATMENT8                                                = 11, // <statment> ::= <input-stmt>
        RULE_CONSTANTDECLARATION_LET_COLON_EQ                         = 12, // <constant-declaration> ::= let <id> ':' <type> '=' <expression>
        RULE_VARIABLEDECLARATION_VAR_COLON                            = 13, // <variable-declaration> ::= var <id> ':' <type>
        RULE_VARIABLEDECLARATION_VAR_COLON_EQ                         = 14, // <variable-declaration> ::= var <id> ':' <type> '=' <expression>
        RULE_ID_ID                                                    = 15, // <id> ::= Id
        RULE_TYPE_INT                                                 = 16, // <type> ::= int
        RULE_TYPE_FLOAT                                               = 17, // <type> ::= float
        RULE_TYPE_BOOL                                                = 18, // <type> ::= bool
        RULE_TYPE_STRING                                              = 19, // <type> ::= string
        RULE_TYPE_VOID                                                = 20, // <type> ::= void
        RULE_EXPRESSION                                               = 21, // <expression> ::= <term>
        RULE_EXPRESSION2                                              = 22, // <expression> ::= <term> <addop> <expr>
        RULE_TERM                                                     = 23, // <term> ::= <factor>
        RULE_TERM2                                                    = 24, // <term> ::= <factor> <mulop> <term>
        RULE_FACTOR                                                   = 25, // <factor> ::= <id>
        RULE_FACTOR2                                                  = 26, // <factor> ::= <num>
        RULE_NUM_NUM                                                  = 27, // <num> ::= Num
        RULE_ADDOP_PLUS                                               = 28, // <addop> ::= '+'
        RULE_ADDOP_MINUS                                              = 29, // <addop> ::= '-'
        RULE_MULOP_TIMES                                              = 30, // <mulop> ::= '*'
        RULE_MULOP_DIV                                                = 31, // <mulop> ::= '/'
        RULE_SELECTIONSTMT                                            = 32, // <selection-stmt> ::= <if-stmt>
        RULE_SELECTIONSTMT2                                           = 33, // <selection-stmt> ::= <switch-stmt>
        RULE_IFSTMT_IF_THEN                                           = 34, // <if-stmt> ::= if <conditions> then <stmt-list>
        RULE_IFSTMT_IF_THEN_ELSE                                      = 35, // <if-stmt> ::= if <conditions> then <stmt-list> else <stmt-list>
        RULE_IFSTMT_IF_THEN2                                          = 36, // <if-stmt> ::= if <condition> <logical-operator> <condition> then <stmt-list>
        RULE_IFSTMT_IF_THEN_ELSE2                                     = 37, // <if-stmt> ::= if <condition> <logical-operator> <condition> then <stmt-list> else <stmt-list>
        RULE_CONDITIONS_LPAREN_RPAREN                                 = 38, // <conditions> ::= '(' <condition> ')'
        RULE_CONDITIONS_LPAREN_RPAREN_LPAREN_RPAREN                   = 39, // <conditions> ::= '(' <condition> ')' <logical-operator> '(' <condition> ')'
        RULE_LOGICALOPERATOR_AND                                      = 40, // <logical-operator> ::= and
        RULE_LOGICALOPERATOR_OR                                       = 41, // <logical-operator> ::= or
        RULE_CONDITION                                                = 42, // <condition> ::= <comparison-expression>
        RULE_COMPARISONEXPRESSION                                     = 43, // <comparison-expression> ::= <expression> <comparison-operator> <expression>
        RULE_COMPARISONOPERATOR_LT                                    = 44, // <comparison-operator> ::= '<'
        RULE_COMPARISONOPERATOR_GT                                    = 45, // <comparison-operator> ::= '>'
        RULE_COMPARISONOPERATOR_LTEQ                                  = 46, // <comparison-operator> ::= '<='
        RULE_COMPARISONOPERATOR_GTEQ                                  = 47, // <comparison-operator> ::= '>='
        RULE_COMPARISONOPERATOR_EQEQ                                  = 48, // <comparison-operator> ::= '=='
        RULE_COMPARISONOPERATOR_EXCLAMEQ                              = 49, // <comparison-operator> ::= '!='
        RULE_SWITCHSTMT_CASE_END                                      = 50, // <switch-stmt> ::= case <expression> <when-stmts> <else> End
        RULE_SWITCHSTMT_CASE_END2                                     = 51, // <switch-stmt> ::= case <expression> <in-stmts> <else> End
        RULE_WHENSTMTS                                                = 52, // <when-stmts> ::= <when-stmt>
        RULE_WHENSTMTS2                                               = 53, // <when-stmts> ::= <when-stmt> <when-stmts>
        RULE_WHENSTMT_WHEN                                            = 54, // <when-stmt> ::= when <expression> <stmt-list>
        RULE_ELSE_ELSE                                                = 55, // <else> ::= else <stmt-list>
        RULE_INSTMTS                                                  = 56, // <in-stmts> ::= <in-stmt>
        RULE_INSTMTS2                                                 = 57, // <in-stmts> ::= <in-stmt> <in-stmts>
        RULE_INSTMT_IN                                                = 58, // <in-stmt> ::= in <values> <stmt-list>
        RULE_VALUES                                                   = 59, // <values> ::= <value>
        RULE_VALUES_COMMA                                             = 60, // <values> ::= <values> ',' <value>
        RULE_VALUE                                                    = 61, // <value> ::= <expression>
        RULE_ITERABLESTMT                                             = 62, // <iterable-stmt> ::= <for-stmt>
        RULE_ITERABLESTMT2                                            = 63, // <iterable-stmt> ::= <while-loop>
        RULE_ITERABLESTMT3                                            = 64, // <iterable-stmt> ::= <do-while-loop>
        RULE_FORSTMT_FOR_LPAREN_COMMA_COMMA                           = 65, // <for-stmt> ::= for '(' <variable-declaration> ',' <condition> ',' <inc>
        RULE_FORSTMT_RPAREN_COLON_ENDFOR                              = 66, // <for-stmt> ::= <dec> ')' ':' <stmt-list> EndFor
        RULE_INC                                                      = 67, // <inc> ::= <expression>
        RULE_INC_PLUSPLUS                                             = 68, // <inc> ::= '++' <id>
        RULE_DEC                                                      = 69, // <dec> ::= <expression>
        RULE_DEC_MINUSMINUS                                           = 70, // <dec> ::= '--' <id>
        RULE_WHILELOOP_WHILE_DO_LBRACE_RBRACE_DONE                    = 71, // <while-loop> ::= while <condition> do '{' <stmt-list> '}' Done
        RULE_DOWHILELOOP_BEGIN_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_DONE = 72, // <do-while-loop> ::= begin '{' <stmt-list> '}' while '(' <condition> ')' Done
        RULE_FUNCTIONDEF_MAKE_LPAREN_RPAREN_LBRACE_RBRACE             = 73, // <function-def> ::= make <func-name> '(' <parameter-list> ')' '{' <stmt-list> '}'
        RULE_PARAMETERLIST                                            = 74, // <parameter-list> ::= <parameter>
        RULE_PARAMETERLIST_COMMA                                      = 75, // <parameter-list> ::= <parameter> ',' <parameter-list>
        RULE_PARAMETER_LPAREN_COLON_RPAREN                            = 76, // <parameter> ::= '(' <id> ':' <type> ')'
        RULE_FUNCNAME                                                 = 77, // <func-name> ::= <id>
        RULE_FUNCTIONCALL_LPAREN_RPAREN                               = 78, // <function-call> ::= <func-name> '(' <argument-list> ')'
        RULE_ARGUMENTLIST                                             = 79, // <argument-list> ::= <expr>
        RULE_ARGUMENTLIST_COMMA                                       = 80, // <argument-list> ::= <expr> ',' <argument-list>
        RULE_EXPR                                                     = 81, // <expr> ::= <id>
        RULE_EXPR2                                                    = 82, // <expr> ::= <function-call>
        RULE_INPUTSTMT_TAKE                                           = 83, // <input-stmt> ::= take <id>
        RULE_PRINTSTMT_SHOW                                           = 84  // <print-stmt> ::= show <id>
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;

        public MyParser(string filename,ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AT :
                //'@'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //and
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BEGIN :
                //begin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DONE :
                //Done
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENDFOR :
                //EndFor
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LET :
                //let
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MAIN :
                //main
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MAKE :
                //make
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //Num
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //or
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHOW :
                //show
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TAKE :
                //take
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THEN :
                //then
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHEN :
                //when
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDOP :
                //<addop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTMINUSLIST :
                //<argument-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BODY :
                //<body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPARISONMINUSEXPRESSION :
                //<comparison-expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPARISONMINUSOPERATOR :
                //<comparison-operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITIONS :
                //<conditions>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTMINUSDECLARATION :
                //<constant-declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEC :
                //<dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOMINUSWHILEMINUSLOOP :
                //<do-while-loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE2 :
                //<else>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMINUSSTMT :
                //<for-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCMINUSNAME :
                //<func-name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONMINUSCALL :
                //<function-call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONMINUSDEF :
                //<function-def>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFMINUSSTMT :
                //<if-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INC :
                //<inc>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INPUTMINUSSTMT :
                //<input-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INMINUSSTMT :
                //<in-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INMINUSSTMTS :
                //<in-stmts>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ITERABLEMINUSSTMT :
                //<iterable-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALMINUSOPERATOR :
                //<logical-operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULOP :
                //<mulop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM2 :
                //<num>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERMINUSLIST :
                //<parameter-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINTMINUSSTMT :
                //<print-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SELECTIONMINUSSTMT :
                //<selection-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //<start>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATMENT :
                //<statment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMTMINUSLIST :
                //<stmt-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHMINUSSTMT :
                //<switch-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUES :
                //<values>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEMINUSDECLARATION :
                //<variable-declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHENMINUSSTMT :
                //<when-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHENMINUSSTMTS :
                //<when-stmts>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILEMINUSLOOP :
                //<while-loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_START_AT_MAIN_LBRACE_RBRACE :
                //<start> ::= '@' main '{' <body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BODY :
                //<body> ::= <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTLIST_COMMA :
                //<stmt-list> ::= <statment> ','
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTLIST_COMMA2 :
                //<stmt-list> ::= <statment> ',' <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT :
                //<statment> ::= <variable-declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT2 :
                //<statment> ::= <constant-declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT3 :
                //<statment> ::= <selection-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT4 :
                //<statment> ::= <iterable-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT5 :
                //<statment> ::= <function-call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT6 :
                //<statment> ::= <function-def>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT7 :
                //<statment> ::= <print-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT8 :
                //<statment> ::= <input-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATION_LET_COLON_EQ :
                //<constant-declaration> ::= let <id> ':' <type> '=' <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_VAR_COLON :
                //<variable-declaration> ::= var <id> ':' <type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_VAR_COLON_EQ :
                //<variable-declaration> ::= var <id> ':' <type> '=' <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_FLOAT :
                //<type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_BOOL :
                //<type> ::= bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_STRING :
                //<type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_VOID :
                //<type> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<expression> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION2 :
                //<expression> ::= <term> <addop> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM2 :
                //<term> ::= <factor> <mulop> <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR2 :
                //<factor> ::= <num>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUM_NUM :
                //<num> ::= Num
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDOP_PLUS :
                //<addop> ::= '+'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDOP_MINUS :
                //<addop> ::= '-'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULOP_TIMES :
                //<mulop> ::= '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULOP_DIV :
                //<mulop> ::= '/'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SELECTIONSTMT :
                //<selection-stmt> ::= <if-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SELECTIONSTMT2 :
                //<selection-stmt> ::= <switch-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_THEN :
                //<if-stmt> ::= if <conditions> then <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_THEN_ELSE :
                //<if-stmt> ::= if <conditions> then <stmt-list> else <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_THEN2 :
                //<if-stmt> ::= if <condition> <logical-operator> <condition> then <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_THEN_ELSE2 :
                //<if-stmt> ::= if <condition> <logical-operator> <condition> then <stmt-list> else <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONS_LPAREN_RPAREN :
                //<conditions> ::= '(' <condition> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONS_LPAREN_RPAREN_LPAREN_RPAREN :
                //<conditions> ::= '(' <condition> ')' <logical-operator> '(' <condition> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOPERATOR_AND :
                //<logical-operator> ::= and
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOPERATOR_OR :
                //<logical-operator> ::= or
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<condition> ::= <comparison-expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONEXPRESSION :
                //<comparison-expression> ::= <expression> <comparison-operator> <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_LT :
                //<comparison-operator> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_GT :
                //<comparison-operator> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_LTEQ :
                //<comparison-operator> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_GTEQ :
                //<comparison-operator> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_EQEQ :
                //<comparison-operator> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPARISONOPERATOR_EXCLAMEQ :
                //<comparison-operator> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTMT_CASE_END :
                //<switch-stmt> ::= case <expression> <when-stmts> <else> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTMT_CASE_END2 :
                //<switch-stmt> ::= case <expression> <in-stmts> <else> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHENSTMTS :
                //<when-stmts> ::= <when-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHENSTMTS2 :
                //<when-stmts> ::= <when-stmt> <when-stmts>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHENSTMT_WHEN :
                //<when-stmt> ::= when <expression> <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELSE_ELSE :
                //<else> ::= else <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSTMTS :
                //<in-stmts> ::= <in-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSTMTS2 :
                //<in-stmts> ::= <in-stmt> <in-stmts>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INSTMT_IN :
                //<in-stmt> ::= in <values> <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUES :
                //<values> ::= <value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUES_COMMA :
                //<values> ::= <values> ',' <value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<value> ::= <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERABLESTMT :
                //<iterable-stmt> ::= <for-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERABLESTMT2 :
                //<iterable-stmt> ::= <while-loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERABLESTMT3 :
                //<iterable-stmt> ::= <do-while-loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORSTMT_FOR_LPAREN_COMMA_COMMA :
                //<for-stmt> ::= for '(' <variable-declaration> ',' <condition> ',' <inc>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORSTMT_RPAREN_COLON_ENDFOR :
                //<for-stmt> ::= <dec> ')' ':' <stmt-list> EndFor
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INC :
                //<inc> ::= <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INC_PLUSPLUS :
                //<inc> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEC :
                //<dec> ::= <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEC_MINUSMINUS :
                //<dec> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILELOOP_WHILE_DO_LBRACE_RBRACE_DONE :
                //<while-loop> ::= while <condition> do '{' <stmt-list> '}' Done
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOWHILELOOP_BEGIN_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_DONE :
                //<do-while-loop> ::= begin '{' <stmt-list> '}' while '(' <condition> ')' Done
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDEF_MAKE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<function-def> ::= make <func-name> '(' <parameter-list> ')' '{' <stmt-list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST :
                //<parameter-list> ::= <parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERLIST_COMMA :
                //<parameter-list> ::= <parameter> ',' <parameter-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_LPAREN_COLON_RPAREN :
                //<parameter> ::= '(' <id> ':' <type> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCNAME :
                //<func-name> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_LPAREN_RPAREN :
                //<function-call> ::= <func-name> '(' <argument-list> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST :
                //<argument-list> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST_COMMA :
                //<argument-list> ::= <expr> ',' <argument-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR2 :
                //<expr> ::= <function-call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INPUTSTMT_TAKE :
                //<input-stmt> ::= take <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINTSTMT_SHOW :
                //<print-stmt> ::= show <id>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + " In line : " + args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "Expected token : " + args.ExpectedTokens.ToString() + "'";
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }

    }
}
