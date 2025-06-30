const bootstrapLink = document.getElementById('bootstrap-css');
const toggleBtn = document.getElementById('theme-toggle');

// Paths to your stylesheets
const lightTheme = '/css/bootstrap.min.css';
const darkTheme = '/css/bootstrap-darkly.min.css';

// Load saved preference
if (localStorage.getItem('theme') === 'dark') {
    bootstrapLink.href = darkTheme;
    toggleBtn.innerHTML = '☀️ Light Mode';
}

toggleBtn.addEventListener('click', () => {
    if (bootstrapLink.href.includes('bootstrap.min.css')) {
        bootstrapLink.href = darkTheme;
        localStorage.setItem('theme', 'dark');
        toggleBtn.innerHTML = '☀️ Light Mode';
    } else {
        bootstrapLink.href = lightTheme;
        localStorage.setItem('theme', 'light');
        toggleBtn.innerHTML = '🌙 Dark Mode';
    }
});