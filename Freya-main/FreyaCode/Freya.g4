grammar Freya;

// Comando para compilar 
// java -jar antlr-4.13.1-complete.jar -Dlanguage=CSharp -visitor Freya.g4 -o Generated

options {
    language = CSharp;
}

// --------------------------------------------------------------------------
// Tokens y símbolos
// --------------------------------------------------------------------------

// Identificadores
ID: [a-zA-Z_] [a-zA-Z_0-9]*;

// Comentarios
LINE_COMMENT: '--' ~[\r\n]* -> skip;
BLOCK_COMMENT: '/*' .*? '*/' -> skip;

// Paréntesis
LPAREN: '(';
RPAREN: ')';

// Tipos de variables
PERCENT_I: '%i';
PERCENT_S: '%s';
PERCENT_F: '%f';

COLON_I: ':i';

// Números
DIGITS: [0-9]+;
FLOAT_NUMBER: DIGITS '.' DIGITS;

// Cadenas con comillas dobles y simples
STRING_DOUBLE: '"' ( ~["\\] | '\\' . )* '"';
STRING_SINGLE: '\'' ( ~['\\] | '\\' . )* '\'';

// Operadores aritméticos
PLUS: '+';
MINUS: '-';
MULT: '*';
DIV: '/';

// Coma
COMMA: ',';

// Espacios en blanco (se ignoran)
WS: [ \t\r\n]+ -> skip;

// --------------------------------------------------------------------------
// Reglas de parser
// --------------------------------------------------------------------------

codeParse: (statement | scriptDef)* EOF;

statement: comment | instruction;

scriptDef
    : 'script' stringLiteral '[' scriptInit? statement* COLON_I 'endfunction' ']'
    ;

scriptInit
    : 'SektStruk' 'native' '{' ( 'StrukKey' variableDef )* '}'
    ;

comment: LINE_COMMENT | BLOCK_COMMENT;

instruction: COLON_I WS? (functionCall | variableDef);

functionCall: ID LPAREN WS? argumentList? WS? RPAREN;

argumentList: argument (WS? COMMA WS? argument)*;

argument: expression | ID;

stringLiteral: STRING_DOUBLE | STRING_SINGLE;

variableDef: ID WS? '=' WS? typeLiteral WS? LPAREN WS? expression WS? RPAREN;

typeLiteral: PERCENT_I | PERCENT_S | PERCENT_F;

// Expresiones con soporte para operaciones aritméticas
expression
    : expression op=(MULT | DIV) expression   # MulDivExpr
    | expression op=(PLUS | MINUS) expression # AddSubExpr
    | LPAREN WS? expression WS? RPAREN        # ParenExpr
    | value                                  # ValueExpr
    | ID                                     # IdExpr
    ;

// Valores literales
value
    : DIGITS              # intValue
    | FLOAT_NUMBER        # floatValue
    | STRING_DOUBLE       # stringDoubleValue
    | STRING_SINGLE       # stringSingleValue
    ;