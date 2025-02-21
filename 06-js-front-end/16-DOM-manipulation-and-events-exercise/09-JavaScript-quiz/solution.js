function /*not so fancy*/solve() {
    let sections = document.querySelectorAll('section');
    let answerTexts = Array.from(document.getElementsByClassName("answer-text"));
    let rightAnswersCount = 0;

    let rightAnswer = answerTexts[0];
    let wrongAnswer = answerTexts[1];

    rightAnswer.addEventListener("click", function() {
        rightAnswersCount++;
        renderSecondPage();
    });

    wrongAnswer.addEventListener("click", function() {
        renderSecondPage();
    });

    function renderSecondPage() {
        sections[0].style.display = 'none';
        sections[1].style.display = 'block';

        let rightAnswer = answerTexts[3];
        let wrongAnswer = answerTexts[2];

        rightAnswer.addEventListener("click", function() {
            rightAnswersCount++;
            renderThirdPage();
        });
    
        wrongAnswer.addEventListener("click", function() {
            renderThirdPage();
        });
    }

    function renderThirdPage() {
        sections[1].style.display = 'none';
        sections[2].style.display = 'block';

        let rightAnswer = answerTexts[4];
        let wrongAnswer = answerTexts[5];

        rightAnswer.addEventListener("click", function() {
            rightAnswersCount++;
            renderFinalPage();
        });
    
        wrongAnswer.addEventListener("click", function() {
            renderFinalPage();
        });
    }

    function renderFinalPage() {
        sections[2].style.display = 'none';
        document.querySelector('#results').style.display = 'block'

        document.querySelector('#results h1').textContent = rightQusetionsCount === 3
            ? 'You are recognized as top JavaScript fan!'
            : `You have ${rightQusetionsCount} right answers`;
    }
}

function fancySolve() {
    let sections = document.querySelectorAll('section');
    let rightAnswersCount = 0;
    let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];

    sections.forEach((section, index) => {
        section.querySelectorAll('.quiz-answer').forEach(answer => {
            answer.addEventListener('click', () => {

                if (answer.textContent.trim() === correctAnswers[index]) {
                    rightAnswersCount++;
                }

                if (index < sections.length - 1) {
                    sections[index].style.display = 'none';
                    sections[index + 1].style.display = 'block';
                } else {
                    showResults(rightAnswersCount);
                }
            });
        });
    });

    function showResults(rightAnswersCount) {
        sections[sections.length - 1].style.display = 'none'; 

        let resultsElement = document.querySelector('#results');
        resultsElement.style.display = 'block';
        resultsElement.querySelector('h1').textContent = rightAnswersCount === 3
            ? 'You are recognized as top JavaScript fan!'
            : `You have ${rightAnswersCount} right answers`;
    }
}