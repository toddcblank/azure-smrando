// door asm of bt/animal room during escape
arch snes.cpu
lorom

// Set up pointer to door asm
org $838BCC
    db $20, $ff

org $8FFF20
    LDA $7ED820 //loads event flags
    BIT #$4000  //checks for escape flag set
    BEQ quit
    LDA #$0015
    STA $7E0946 //stores 15 to escape timer in seconds

    quit:
    RTS 