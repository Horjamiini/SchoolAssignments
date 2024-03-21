#!/bin/bash

apu=0
declare Heronames
while [ $apu -lt 3 ]
do
Heronames+=$(cat superhero.json | jq .members[$apu].name)
(( apu++  ))
done

abu=0
while [ $abu -eq 0 ] 
do
echo $Heronames
read -p "Which of these heroes you want to know about (write exit to exit): " heroinput
  if [[ $heroinput = "Molecule Man" ]] || [[ $heroinput = "Madame Uppercut" ]] || [[ $heroinput = "Eternal Flame" ]]
  then
   if [[ $heroinput = "Molecule Man" ]]
    then
     heronumber=0
      read -p "What do you want to know [Identity or Powers]: " infoinput
      if [ $infoinput = "Identity" ]
      then
       identity=$(cat superhero.json | jq .members[$heronumber].secretIdentity)
        echo "Identity of ${heroinput} is: ${identity}"
      elif [ $infoinput = "Powers" ]
      then
       powers=$(cat superhero.json | jq .members[$heronumber].powers)
        echo "Powers of ${heroinput} are: ${powers}"
      else
       echo "Incorrect input"
      fi

   elif [[ $heroinput = "Madame Uppercut" ]]
    then
     heronumber=1
     read -p "What do you want to know [Identity or Powers]: " infoinput
     if [ $infoinput = "Identity" ]
       then
        identity=$(cat superhero.json | jq .members[$heronumber].secretIdentity)
        echo "Identity of ${heroinput} is: ${identity}"
     elif [ $infoinput = "Powers" ]
     then
        powers=$(cat superhero.json | jq .members[$heronumber].powers)
        echo "Powers of ${heroinput} are: ${powers}"
      else
       echo "Incorrect input"
      fi

    elif [[ $heroinput = "Eternal Flame" ]]
    then
     heronumber=2
     read -p "What do you want to know [Identity or Powers]: " infoinput
     if [ $infoinput = "Identity" ]
       then
        identity=$(cat superhero.json | jq .members[$heronumber].secretIdentity)
        echo "Identity of ${heroinput} is: ${identity}"
      elif [ $infoinput = "Powers" ]
      then
        powers=$(cat superhero.json | jq .members[$heronumber].powers)
        echo "Powers of ${heroinput} are: ${powers}"
      else
       echo "Incorrect input"
      fi

  fi
elif [ $heroinput = "Exit" ] || [ $heroinput = "exit" ]
then
(( abu++ ))
 
else
 echo "Incorrect hero name!"
fi
done
