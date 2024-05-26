async function fetchHotels() {
    const response = await fetch('/api/Hotel');
    return response.json();
}

export { fetchHotels };