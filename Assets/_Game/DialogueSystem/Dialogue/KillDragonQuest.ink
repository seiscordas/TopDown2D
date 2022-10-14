INCLUDE Globals.ink
-> main

=== main ===
Can help us by killing the mighty dragon in the field?
->choices

=== choices ===
    *[No, I can't.]
        ->chosenNo 
    *[Yes, I can.]
        ~ acceptQuest = true
        ->chosenYes

=== chosenYes ===
thanks man!
Take this letter and give it to the king
Remember! You have to hit on the dragons head and run from its fire.

->DONE 

=== chosenNo ===
Ok man!

->END
