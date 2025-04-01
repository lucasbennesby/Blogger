

const QUANTIDADE_DE_PARTICULAS = 5;
const RANDOMIZADOR_DE_TAMANHO = 20 + 5;
const DISTANCIA_DAS_PARTICULAS = 50;
const FONT_SIZE_PARTICULAS = 24 + 10;
function pop(e) {
    // Quick check if user clicked the button using a keyboard
    if (e.clientX === 0 && e.clientY === 0) {
        const bbox = document.querySelector('.like-star').getBoundingClientRect();
        const x = bbox.left + bbox.width / 2;
        const y = bbox.top + bbox.height / 2;
        for (let i = 0; i < QUANTIDADE_DE_PARTICULAS; i++) {
            // We call the function createParticle 30 times
            // We pass the coordinates of the button for x & y values
            createParticle(x, y);
        }
    } else {
        for (let i = 0; i < QUANTIDADE_DE_PARTICULAS; i++) {
            // We call the function createParticle 30 times
            // As we need the coordinates of the mouse, we pass them as arguments
            createParticle(e.clientX, e.clientY);
        }
    }
}
function createParticle(x, y) {
    const particle = document.createElement('particle');
    document.body.appendChild(particle);

    // Calculate a random size from 5px to 25px
    const size = Math.floor(Math.random() * 5 + 25  );
    particle.style.width = `${size}px`;
    particle.style.height = `${size}px`;
    // Generate a random color in a blue/purple palette
    //particle.style.background = `hsl(${Math.random() * 90 + 180}, 70%, 60%)`;
    //particle.innerHTML = ['❤', '🧡', '💛', '💚', '💙', '💜', '🤎'][Math.floor(Math.random() * 2)];
    particle.innerHTML = ['𓇼', '𓇼', '𓇼', '𓇼', '𓇼', '𓇼', '𓇼'][Math.floor(Math.random() * 2)];
    particle.style.fontSize = `${Math.random() * FONT_SIZE_PARTICULAS}px`;
    particle.style.color = '#FFBF00';
    width = height = 'auto';

    // Generate a random x & y destination within a distance of DISTANCIA_DAS_PARTICULAS from the mouse
    const destinationX = x + (Math.random() - 0.5) * 2 * DISTANCIA_DAS_PARTICULAS;
    const destinationY = y + (Math.random() - 0.5) * 2 * DISTANCIA_DAS_PARTICULAS;

    // Store the animation in a variable as we will need it later
    const animation = particle.animate([
        {
            // Set the origin position of the particle
            // We offset the particle with half its size to center it around the mouse
            transform: `translate(-50%, -50%) translate(${x}px, ${y}px)`,
            opacity: 1
        },
        {
            // We define the final coordinates as the second keyframe
            transform: `translate(${destinationX}px, ${destinationY}px)`,
            opacity: 0
        }
    ], {
        // Set a random duration from 500 to 1500ms
        duration: Math.random() * 1000 + 500,
        easing: 'cubic-bezier(0, .9, .57, 1)',
        // Delay every particle with a random value of 200ms
        delay: Math.random() * 200
    });

    // When the animation is complete, remove the element from the DOM
    animation.onfinish = () => {
        particle.remove();
    };
}