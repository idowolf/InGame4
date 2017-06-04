// JavaScript source code
		/* When called, generate a new parachutist at plane position and grant it gravity */ 
        function createNewParachutist() {
            var parachutistObj = parachutistsContainer.create(planeObj.position.x + game.cache.getImage('parachutistImage').width,
                planeObj.position.y + game.cache.getImage('parachutistImage').height / 2, 'parachutistImage');
            parachutistObj.body.gravity.y = fallingSpeed;
        }

