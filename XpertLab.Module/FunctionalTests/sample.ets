;#DropDB XpertLabEasyTest

#Application XpertLabWin
#Application XpertLabBlazor

*FillForm
 User Name = Admin
*Action Log In

#IfDef XpertLabWin

*Action About...
 
*Action OK

#EndIf

#IfDef XpertLabBlazor
*Action Navigation(My Details)
#EndIf
