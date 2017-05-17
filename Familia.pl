progenitor(clara,jose).
progenitor(tomas,jose).
progenitor(tomas,isabel).
progenitor(jose,ana).
progenitor(jose,patricia).
progenitor(patricia,jaime).

progenitor(erick,clara).
progenitor(erick,tomas).
progenitor(ana,luisa).
progenitor(jaime,maria).
progenitor(maria,guillermo).
progenitor(patricia,arturo).
progenitor(arturo,guillermo).

hombre(jose).
hombre(tomas).
hombre(jaime).
hombre(erick).
hombre(guillermo).
hombre(arturo).

mujer(clara).
mujer(isabel).
mujer(ana).
mujer(patricia).
mujer(luisa).
mujer(maria).

dif(X,Y):-(X\=Y).

es_madre(X):-mujer(X),progenitor(X,_).
es_padre(X):-hombre(X),progenitor(X,_).
es_hijo(X):-hombre(X),progenitor(_,X).
hermana_de(X,Y):-mujer(X),progenitor(Z,X),progenitor(Z,Y),dif(X,Y).
abuelo_de(X,Y):-hombre(X),progenitor(X,Z),progenitor(Z,Y).
abuela_de(X,Y):-mujer(X),progenitor(X,Z),progenitor(Z,Y).
hermanos(X,Y):-progenitor(Z,X),progenitor(Z,Y),dif(X,Y).
tia(X,Y):-mujer(X),progenitor(Z,Y),hermanos(Z,X).

antecesor(X,Y):-progenitor(X,Y).
antecesor(X,Y):-progenitor(Z,Y),antecesor(X,Z).

sucesor(X,Y):- progenitor(Y,X).
sucesor(X,Y):- progenitor(Z,X),sucesor(Z,Y).

cargar(A):-exists_file(A),consult(A).