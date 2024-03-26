const result = document.querySelector('.result')
const baseUrl = `${window.location.origin}/api`
const fetchAlbums = async () => {
  try {
    const { data } = await axios.get(`${baseUrl}/albums`)

    const albums = data.map((album) => {
      return `<ul><li> Artist: ${album.artist}</li><li> Title: ${album.title}</li><li> Genre: ${album.genre}</li></ul>`
    })
    result.innerHTML = albums.join('')
  } catch (error) {
    console.log(error)
    result.innerHTML = `<div class="alert alert-danger">Could not fetch data</div>`
  }
}
fetchAlbums()