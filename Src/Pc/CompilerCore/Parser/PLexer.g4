﻿lexer grammar PLexer;

// Type names

ANY       : 'any' ;
BOOL      : 'bool' ;
SECURE_BOOL  : 'secure_bool' ;
ENUM      : 'enum' ;
EVENT     : 'event' ;
EVENTSET  : 'eventset' ;
FLOAT     : 'float' ;
INT       : 'int' ;
SECURE_INT : 'secure_int' ;
MACHINE   : 'machine';
SECURE_MACHINE : 'secure_machine';
INTERFACE : 'interface' ;
MAP       : 'map' ;
SET       : 'set' ;
SEQ       : 'seq' ;
DATA      : 'data' ;
STRING    : 'string';

// Keywords

ANNOUNCE  : 'announce' ;
AS        : 'as' ;
ASSERT    : 'assert' ;
ASSUME    : 'assume' ;
TRUSTED : 'trusted' ;
BREAK     : 'break' ;
CASE      : 'case' ;
COLD      : 'cold' ;
CONTINUE  : 'continue' ;
DEFAULT   : 'default' ;
DEFER     : 'defer' ;
DO        : 'do' ;
ELSE      : 'else' ;
ENTRY     : 'entry' ;
EXIT      : 'exit' ;
FORMAT : 'format';
FUN       : 'fun' ;
GOTO      : 'goto' ;
GROUP     : 'group' ;
HALT      : 'halt' ;
HOT       : 'hot' ;
IF        : 'if' ;
IGNORE    : 'ignore' ;
IN        : 'in' ;
KEYS      : 'keys' ;
MOVE      : 'move' ;
NEW       : 'new' ;
OBSERVES  : 'observes' ;
ON        : 'on' ;
POP       : 'pop' ;
PRINT     : 'print' ;
PUSH      : 'push' ;
RAISE     : 'raise' ;
RECEIVE   : 'receive' ;
RETURN    : 'return' ;
SEND      : 'send' ;
SECURE_SEND : 'secure_send' ;
UNTRUSTED_SEND : 'untrusted_send' ;
UNENCRYPTED_SEND : 'unencrypted_send' ;
SIZEOF    : 'sizeof' ;
SPEC      : 'spec' ;
START     : 'start' ;
STATE     : 'state' ;
SWAP      : 'swap' ;
THIS      : 'this' ;
SECURE_THIS : 'secure_this' ;
TYPE      : 'type' ;
VALUES    : 'values' ;
VAR       : 'var' ;
WHILE     : 'while' ;
WITH      : 'with' ;

// module-system-specific keywords

// module-test-implementation declarations
MODULE         : 'module' ;
IMPLEMENTATION : 'implementation' ;
TEST           : 'test' ;
REFINES        : 'refines' ;

// module constructors
COMPOSE        : 'compose' ;
UNION          : 'union'    ;
HIDEE          : 'hidee' ;
HIDEI          : 'hidei' ;
RENAME         : 'rename' ;
SAFE           : 'safe' ;
MAIN		   : 'main' ;

// machine annotations
RECEIVES  : 'receives' ;
SENDS     : 'sends' ;

// Common keywords
CREATES : 'creates' ;
TO      : 'to' ;

// Literals

BoolLiteral : 'true' | 'false' ;

IntLiteral : [0-9]+ ;

NullLiteral : 'null';

StringLiteral : '"' StringCharacters? '"' ;
fragment StringCharacters : StringCharacter+ ;
fragment StringCharacter : ~["\\] | EscapeSequence ;
fragment EscapeSequence : '\\' . ;

// Symbols

FAIRNONDET : '$$' ;
NONDET     : '$'  ;

LNOT   : '!' ;
LAND   : '&&' ;
LOR    : '||' ;

EQ     : '==' ;
NE     : '!=' ;
LE     : '<=' ;
GE     : '>=' ;
LT     : '<'  ;
GT     : '>'  ;
RARROW : '->' ;

ASSIGN : '=' ;
INSERT : '+=' ;
REMOVE : '-=' ;

ADD    : '+' ;
SUB    : '-' ;
MUL    : '*' ;
DIV    : '/' ;

LBRACE : '{' ;
RBRACE : '}' ;
LBRACK : '[' ;
RBRACK : ']' ;
LPAREN : '(' ;
RPAREN : ')' ;
SEMI   : ';' ;
COMMA  : ',' ;
DOT    : '.' ;
COLON  : ':' ;
CREATE_LOC : '@' ;

// Identifiers

Iden : PLetter PLetterOrDigit* ;
fragment PLetter : [a-zA-Z_] ;
fragment PLetterOrDigit : [a-zA-Z0-9_] ;

// Non-code regions

Whitespace : [ \t\r\n\f]+ -> skip ;
BlockComment : '/*' .*? '*/' -> channel(HIDDEN) ;
LineComment : '//' ~[\r\n]* -> channel(HIDDEN) ;
